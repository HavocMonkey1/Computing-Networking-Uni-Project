import time#imports the modules needed
import DatabaseInterface


def SaveNote(request):#defines the function SaveNote
    NoteHeading = DatabaseInterface.SanitiseInput(request.headers["NoteHeading"])#Sanatises the input and declares the variable NoteHeading with the scope of the function by pulling a string from the heading NoteHeading
    ContentLength = request.headers["Content-length"]#pulls the variable from the header
    NoteBody = DatabaseInterface.SanitiseInput(request.rfile.read(int(ContentLength)))#declares variable as above with sanitisation
    Token = DatabaseInterface.SanitiseInput(request.headers["Token"])#see above
    UserID = None#declares the variable within the scope
    error_message = "Session token expired."#as above
    Authorized = False#As above and default condition False
    Updated = False#As above and default condition False

    DatabaseInterface.dbCursor.execute("SELECT UserID, Timeout FROM note_taking_database.sessions WHERE Token = \"" + str(Token) +"\"")#runs an SQL query on the database using the credentials provided in
    CheckTokenExistsResponse = DatabaseInterface.dbCursor.fetchall()
    for x in CheckTokenExistsResponse:#Authoristion process
        print(x)
        UserID = x[0]#first term returned will be the UserID
        if x[1].timestamp() >= time.time():#Checks if the Timeout timestamp of the token is bigger than the current time checking that the token hasn't expired
            Authorized = True#if token valid user is authorized
        else:#otherwise the user recieves a 401 error
            request.send_response(401)
            request.send_header('content-type', 'text/plain')
            request.send_header('content-length', len(error_message))
            request.end_headers()
            request.wfile.write((error_message).encode())
    if Authorized == True:#if user authorized it performs the save function
        DatabaseInterface.dbCursor.execute("SELECT HeaderContents, NoteID FROM note_taking_database.text_contents WHERE UserID = " + str(UserID))#queriess all the note headings the user has
        CheckNoteExistsResponse = DatabaseInterface.dbCursor.fetchall()#recalls the results of the query to a variable
        for y in CheckNoteExistsResponse:#iterates through all the note headings the user has
            print(y)
            if y[0] == NoteHeading:#if the noteheading it's itterating matches then noteheader that the user has requested to save
                Updated = True#toggles a boolean to prevent duplicate file naming
                NoteID = y[1]#pulls the noteID of the note
                DatabaseInterface.dbCursor.execute("UPDATE note_taking_database.text_contents SET TextContents = \"" + str(NoteBody) +"\" WHERE NoteID = " + str(NoteID))#query to replace the note body in the database of the corresponding note with the matching NoteID with the new note contents
                DatabaseInterface.dbConnection.commit()#actions the above query
        if Updated == False:#if it hasn't found and updated the note it will make a new note
            DatabaseInterface.dbCursor.execute("INSERT INTO note_taking_database.text_contents (UserID, TextContents, HeaderContents) VALUES (" + str(UserID) + ", \"" + str(NoteBody) + "\" ,\"" + str(NoteHeading) + "\")")#query to make a new note with the UserID, Notheading and note body, the NoteID will automatically be generate due to the database settings
            DatabaseInterface.dbConnection.commit()#actions the above query


def LoadNote(request):#For load requests
    NoteHeading = DatabaseInterface.SanitiseInput(request.headers["NoteHeading"])#Same heading handling techniques and variable declarations as previous function
    NoteBody = None
    Token = DatabaseInterface.SanitiseInput(request.headers["Token"])
    UserID = None
    error_message = "Session token expired."
    Authorized = False
    Updated = False
#Start or authorisation process as above
    DatabaseInterface.dbCursor.execute("SELECT UserID, Timeout FROM note_taking_database.sessions WHERE Token = \"" + str(Token) +"\"")
    CheckTokenExistsResponse = DatabaseInterface.dbCursor.fetchall()
    for x in CheckTokenExistsResponse:
        print(x)
        UserID = x[0]
        if x[1].timestamp() >= time.time():
            Authorized = True
        else:
            request.send_response(401)
            request.send_header('content-type', 'text/plain')
            request.send_header('content-length', len(error_message))
            request.end_headers()
            request.wfile.write((error_message).encode())#end of authorisation process
    if Authorized == True:#if authorised
        DatabaseInterface.dbCursor.execute("SELECT TextContents FROM note_taking_database.text_contents WHERE HeaderContents = \"" + str(NoteHeading) + "\" AND UserID = " + str(UserID))#SQL query to pull the note contents from the database where the note heading and user ID matches the data pulled from the request
        response = DatabaseInterface.dbCursor.fetchall()#fetches the responses of the query from memory
        for y in response:#iterates through only needed for testing purposes
            print(y)
        NoteBody = str(response[0][0])#pulls as a string the notebody

        request.send_response(200)#sends ok message with the body being the note text
        request.send_header('content-type', 'text/plain')
        request.send_header('content-length', len(NoteBody))

        request.end_headers()

        request.wfile.write(NoteBody.encode())


def ListNotes(request):#function to handle the updating of the list of notes
    Token = DatabaseInterface.SanitiseInput(request.headers["Token"])#header handling and variables
    UserID = None
    error_message = "Session token expired."
    Authorized = False
    NotesList = None

    DatabaseInterface.dbCursor.execute("SELECT UserID, Timeout FROM note_taking_database.sessions WHERE Token = \"" + str(Token) + "\"")#authorization
    CheckTokenExistsResponse = DatabaseInterface.dbCursor.fetchall()
    for x in CheckTokenExistsResponse:
        print(x)
        UserID = x[0]
        if x[1].timestamp() >= time.time():
            Authorized = True
        else:
            request.send_response(401)
            request.send_header('content-type', 'text/plain')
            request.send_header('content-length', len(error_message))
            request.end_headers()
            request.wfile.write((error_message).encode())#authorization
    if Authorized == True:
        DatabaseInterface.dbCursor.execute("SELECT HeaderContents FROM note_taking_database.text_contents WHERE UserID = \"" + str(UserID) + "\"")#SQL Query for all headers belonging to user
        NoteList = DatabaseInterface.dbCursor.fetchall()#recall from memory
        print(NoteList)
        for Notes in NoteList:#Iterates through assigning them to a text string with return and newline in between each item
            print(Notes)
            NotesList = str(NotesList) + str(Notes[0]) + "\r\n"
            print(NotesList[4:])
        request.send_response(200)#sends ok message with the list of all the headers sent accross in the body with the initial placeholder text removed from the string
        request.send_header('content-type', 'text/plain')
        request.send_header('content-length', len(NotesList)-4)
        request.end_headers()
        request.wfile.write((NotesList[4:]).encode())