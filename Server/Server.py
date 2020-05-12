from http.server import HTTPServer, BaseHTTPRequestHandler
import LoginHandler
import UserControlHandler
import FileHandler

class SuperHandler(BaseHTTPRequestHandler):#the super handler which handles all request passing them on to the relevant handlers
    def do_GET(self):
        if self.path == "/Login":
            LoginHandler.processLogin(self)#passes the /Login requests onto the Login Handler script
        elif self.path == "/FileHandler":
            pass
        elif self.path == "/UserControl":
            pass
        else:
            self.send_response(404)

    def do_POST(self):
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
