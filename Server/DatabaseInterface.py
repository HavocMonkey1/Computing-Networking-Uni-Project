import mysql.connector#a library designed to interface with mysql databases (Such as the database that I have set up for the backend

dbConnection = mysql.connector.connect(#the login details for talking to the database
    host="localhost",
    user="Queries",
    passwd="Queries123",
    database="note_taking_database"
)

dbCursor = dbConnection.cursor(buffered=True)

def SanitiseInput(input):#a function to sanatise the input to protect against SQL injection which allows people to run queries which they're not authorised to run
    #todo actually sanitise inputs to protect against SQL injection
    return input