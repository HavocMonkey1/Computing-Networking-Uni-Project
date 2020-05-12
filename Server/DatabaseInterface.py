import mysql.connector

dbConnection = mysql.connector.connect(
    host="localhost",
    user="Queries",
    passwd="Queries123",
    database="note_taking_database"
)

dbCursor = dbConnection.cursor(buffered=True)

def SanitiseInput(input):
    #todo actually sanitise inputs to protect against SQL injection
    return input