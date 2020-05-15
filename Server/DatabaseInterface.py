import mysql.connector#a library designed to interface with mysql databases (Such as the database that I have set up for the backend

dbConnection = mysql.connector.connect(#the login details for talking to the database
    host="localhost",
    user="Queries",
    passwd="Queries123",
    database="note_taking_database"
)

dbCursor = dbConnection.cursor(buffered=True)#establishes a cursor used for querying the database, buffered = True means that it stores the data in memory which is pulled from the database

def SanitiseInput(input):#a function to sanitise the input to protect against SQL injection which allows people to run queries which they're not authorised to run
    input = str(input).replace('\"',"").replace("\'", "")#replaces any ' or " with nothing removing them from the string
    return str(input)#returns the modified input as the output