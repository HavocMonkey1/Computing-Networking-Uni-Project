import time
import DatabaseInterface


def SaveNote(request):
    NoteHeading = DatabaseInterface.SanitiseInput(request.headers["NoteHeading"])
    ContentLength = request.headers["Content-length"]
    NoteBody = DatabaseInterface.SanitiseInput(request.rfile.read(int(ContentLength)))
    Token = DatabaseInterface.SanitiseInput(request.headers["Token"])
    UserID = None
    error_message = "Session token expired."
    Authorized = False
    Updated = False

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
            request.wfile.write((error_message).encode())
    if Authorized == True:
        DatabaseInterface.dbCursor.execute("SELECT HeaderContents, NoteID FROM note_taking_database.text_contents WHERE UserID = " + str(UserID))
        CheckNoteExistsResponse = DatabaseInterface.dbCursor.fetchall()
        for y in CheckNoteExistsResponse:
            print(y)
            if y[0] == NoteHeading:
                Updated = True
                NoteID = y[1]
                DatabaseInterface.dbCursor.execute("UPDATE note_taking_database.text_contents SET TextContents = \"" + str(NoteBody) +"\" WHERE NoteID = " + str(NoteID))
                DatabaseInterface.dbConnection.commit()
        if Updated == False:
            DatabaseInterface.dbCursor.execute("INSERT INTO note_taking_database.text_contents (UserID, TextContents, HeaderContents) VALUES (" + str(UserID) + ", \"" + str(NoteBody) + "\" ,\"" + str(NoteHeading) + "\")")
            DatabaseInterface.dbConnection.commit()


def LoadNote(request):
    NoteHeading = DatabaseInterface.SanitiseInput(request.headers["NoteHeading"])
    NoteBody = None
    Token = DatabaseInterface.SanitiseInput(request.headers["Token"])
    UserID = None
    error_message = "Session token expired."
    Authorized = False
    Updated = False

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
            request.wfile.write((error_message).encode())
    if Authorized == True:
        DatabaseInterface.dbCursor.execute("SELECT TextContents FROM note_taking_database.text_contents WHERE HeaderContents = \"" + str(NoteHeading) + "\" AND UserID = " + str(UserID))
        response = DatabaseInterface.dbCursor.fetchall()
        for y in response:
            print(y)
        NoteBody = str(response[0][0])
        request.send_response(200)
        request.send_header('content-type', 'text/plain')

        temp = NoteBody.encode()
        request.send_header('content-length', len(NoteBody))
        request.end_headers()
        request.wfile.write(NoteBody.encode())


def ListNotes(request):
    Token = DatabaseInterface.SanitiseInput(request.headers["Token"])
    UserID = None
    error_message = "Session token expired."
    Authorized = False
    NotesList = None

    DatabaseInterface.dbCursor.execute("SELECT UserID, Timeout FROM note_taking_database.sessions WHERE Token = \"" + str(Token) + "\"")
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
            request.wfile.write((error_message).encode())
    if Authorized == True:
        DatabaseInterface.dbCursor.execute("SELECT HeaderContents FROM note_taking_database.text_contents WHERE UserID = \"" + str(UserID) + "\"")
        NoteList = DatabaseInterface.dbCursor.fetchall()
        print(NoteList)
        for Notes in NoteList:
            print(Notes)
            NotesList = str(NotesList) + str(Notes[0]) + "\r\n"
            print(NotesList[4:])
        request.send_response(200)
        request.send_header('content-type', 'text/plain')
        request.send_header('content-length', len(NotesList)-4)
        request.end_headers()
        request.wfile.write((NotesList[4:]).encode())