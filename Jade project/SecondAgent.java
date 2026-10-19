import jade.core.Agent;
import jade.core.behaviours.CyclicBehaviour;
import jade.lang.acl.ACLMessage;
import javax.swing.*;

public class SecondAgent extends Agent {
    @Override
    protected void setup() {
        System.out.println("=== Агент Receiver запущен ===");
        addBehaviour(new CyclicBehaviour() {
            @Override
            public void action() {
                ACLMessage msg = receive();
                if (msg != null) {
                    System.out.println("Receiver получил: " + msg.getContent());
                    JOptionPane.showMessageDialog(null, msg.getContent());
                } else {
                    block();
                }
            }
        });
    }
}