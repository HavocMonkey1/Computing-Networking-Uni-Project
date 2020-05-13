from http.server import HTTPServer, BaseHTTPRequestHandler
import LoginHandler
import UserControlHandler
import FileHandler

class SuperHandler(BaseHTTPRequestHandler):#the super handler which handles all request passing them on to the relevant handlers
    def do_GET(self):#A handler for all the GET requests the server recieves
        if self.path == "/Login":#checks the path of the request
            LoginHandler.processLogin(self)#passes the /Login requests onto the Login Handler script
        elif self.path == "/FileHandler":#checks the path of the request
            pass
        elif self.path == "/UserControl":#checks the path of the request
            pass
        else:#if the path doesn't match any of the routes that I've set up it will return a 404 error meaning that path couldn't be found
            self.send_response(404)

    def do_POST(self):#same as the GET handler but for post requests
        if self.path == "/FileHandler":
            pass
        elif self.path =="/UserControl":
            pass
        else:
            self.sendresponse(404)


if __name__ == '__main__':
    server_address = ('', 8000)  # Serve on all addresses, port 8000.
    httpd = HTTPServer(server_address, SuperHandler)
    httpd.serve_forever()
