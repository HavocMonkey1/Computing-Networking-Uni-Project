import  DatabaseInterface
import time
from datetime import datetime

def processLogin(request):
    InputUsername = DatabaseInterface.SanitiseInput(request.headers["Username"])
    InputPassword = DatabaseInterface.SanitiseInput(request.headers["Password"])
    UserID = None

    DatabaseInterface.dbCursor.execute("SELECT UserID FROM note_taking_database.users WHERE UserName = \"" + InputUsername + "\" AND UserPassword = \"" + InputPassword + "\"")#runs a query on the database to validate the inputted username and password
    response = DatabaseInterface.dbCursor.fetchall()
    for x in response:
        print(x)
        Temp = x
        UserID = Temp[0]#assigns the first item in the Tuple as the User ID

    if len(response) == 0:#because of the way that the database has been structured with each username having to be unique, if the query finds anything there will only ever be a single result so the tuple, response, will be of length 1
        Token_Part_1 = InputUsername.encode('utf-8')
        print(Token_Part_1)
        Token_Part_1 = Token_Part_1.hex()
        print(Token_Part_1)
        Token_part_2 = hex(int(time.time()))
        print(Token_part_2)
        Token = Token_Part_1+Token_part_2[2:]
        print(Token)

        TimeStamp =datetime.utcfromtimestamp(time.time()).strftime('%Y-%m-%d %H:%M:%S')
        Timeout = datetime.utcfromtimestamp(time.time()+18000).strftime('%Y-%m-%d %H:%M:%S')
        DatabaseInterface.dbCursor.execute("INSERT INTO sessions (Token, UserID, Timeout) VALUES (\""+Token+"\", "+str(UserID)+", \""+Timeout +"\")")#Creates the query which enters the data into the sessions table in the database
        DatabaseInterface.dbConnection.commit()#Actions the above query, writting it to the database


    else:
        request.send_response(401)
