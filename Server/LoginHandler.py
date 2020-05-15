import  DatabaseInterface
import time
from datetime import datetime

def processLogin(request):#the function for handling login requests
    InputUsername = DatabaseInterface.SanitiseInput(request.headers["Username"])#sanitisation function in order to prevent unortharized access tot the database
    InputPassword = DatabaseInterface.SanitiseInput(request.headers["Password"])
    UserID = None #creates a variable called UserID with a null value outside the scope of the for loop so that it doesn't get cleared from memory when it completes the for loop
    error_message = "Wrong username or password."

    DatabaseInterface.dbCursor.execute("SELECT UserID FROM note_taking_database.users WHERE UserName = \"" + InputUsername + "\" AND UserPassword = \"" + InputPassword + "\"")#runs a query on the database to validate the inputted username and password
    response = DatabaseInterface.dbCursor.fetchall()#pulls the information from the query above out of the location that it's been stored to in memory and creates a tuple called response
    for x in response:#iterates through the tuple response
        print(x)
        Temp = x#creates a temporary variable which is also
        UserID = Temp[0]#assigns the first item in the Tuple as the User ID, if the tuple is empty then nothing gets returned

    if len(response) == 1:#because of the way that the database has been structured with each username having to be unique, if the query finds anything there will only ever be a single result so the tuple, response, will be of length 1
        Token_Part_1 = InputUsername.encode('utf-8')#stores the user name as a bytes representation of the user name
        print(Token_Part_1)
        Token_Part_1 = Token_Part_1.hex()#converts the bytes into hex
        print(Token_Part_1)
        Token_part_2 = hex(int(time.time()))#takes the current time and stores it as a hex
        print(Token_part_2)
        Token = Token_Part_1+Token_part_2[2:]#concatenates the two halves of the token to create a session token that combines both a hexversion of the username and the time
        print(Token)

        TimeStamp =datetime.utcfromtimestamp(time.time()).strftime('%Y-%m-%d %H:%M:%S')#creates a timestamp from the python time module and formats it using the date time module, however this is currently redundant
        Timeout = datetime.utcfromtimestamp(time.time()+18000).strftime('%Y-%m-%d %H:%M:%S')#adds 5 hours onto the current time and formats it as date time in order to store the time of expiration of the token in the right format for the database
        DatabaseInterface.dbCursor.execute("INSERT INTO sessions (Token, UserID, Timeout) VALUES (\""+Token+"\", "+str(UserID)+", \""+Timeout +"\")")#Creates the query which enters the data into the sessions table in the database
        DatabaseInterface.dbConnection.commit()#Actions the above query, writting it to the database

        request.send_response(200)
        request.send_header('Content-type', 'text/plain')
        request.send_header('Content-length', len(Token))
        request.end_headers()
        request.wfile.write((Token).encode())




    else:
        request.send_response(401)
        request.send_header('Content-type', 'text/plain')
        request.send_header('Content-length', len(error_message))
        request.end_headers()
        request.wfile.write((error_message).encode())