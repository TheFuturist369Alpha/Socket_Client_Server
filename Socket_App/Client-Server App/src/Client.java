import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.InetAddress;
import java.net.Socket;


//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Client {
    public static void main(String[] args) {
        try {
            InetAddress address = InetAddress.getLocalHost();
            Socket csocket = new Socket(address.getHostAddress(), 402);
            BufferedReader reader=new BufferedReader(new InputStreamReader(System.in));
            System.out.println("Enter a message: ");
            String message=reader.readLine();
            PrintWriter writer=new PrintWriter(csocket.getOutputStream(), true);
            writer.println(message);
            BufferedReader reader1=new BufferedReader(new InputStreamReader(csocket.getInputStream()));
            String message1;
            while((message1=reader1.readLine())!=null)
             System.out.println(message1);
            csocket.close();
        }
        catch (Exception e){
            e.printStackTrace();
        }




        }
    }
