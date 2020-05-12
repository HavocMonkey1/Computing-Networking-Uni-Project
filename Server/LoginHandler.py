import  DatabaseInterface

def processLogin(request):
    InputUsername = DatabaseInterface.SanitiseInput(request.headers["Username"])
    InputPassword = DatabaseInterface.SanitiseInput(request.headers["Password"])

    DatabaseInterface.dbCursor.execute("SELECT UserID FROM note_taking_database.users WHERE UserName = \"" + InputUsername + "\" AND UserPassword = \"" + InputPassword + "\"")
    response = DatabaseInterface.dbCursor.fetchall()
    for x in response:
        print(x)