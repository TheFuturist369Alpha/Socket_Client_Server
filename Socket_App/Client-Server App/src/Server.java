import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;

public class Server {

    public static void main(String[] arg) {
        System.out.println("Listening at port:402...");
        try {
            ServerSocket ssocket = new ServerSocket(402);
            Socket socket=ssocket.accept();
            System.out.println("CONNECTION ESTABLISHED.");
            BufferedReader reader=new BufferedReader(new InputStreamReader(socket.getInputStream()));
            PrintWriter writer=new PrintWriter(socket.getOutputStream(),true);
            String message=reader.readLine();
            StringBuilder builder=new StringBuilder();
           for(int i=0; i<5; i++) {
                builder.append("\n\"").append(message).append("\"");
            }
            writer.println(builder);
           socket.close();

        }
        catch(Exception e){
            e.getStackTrace();
        }
    }

}
