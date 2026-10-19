import jade.core.Agent;
import jade.core.AID;
import jade.core.behaviours.OneShotBehaviour;
import jade.lang.acl.ACLMessage;

public class FirstAgentTest extends Agent {
    protected void setup() {
        System.out.println("=== Агент Sender запущен ===");
        Object[] args = getArguments();
        String content = "Данные не получены";
        
        // Читаем два аргумента
        if (args != null && args.length >= 2) {
            content = "Стоимость ФЗО (Yadro): " + args[0] + " млн. руб.\n" +
                      "Стоимость ФНО (X Company): " + args[1] + " млн. руб.";
        } else if (args != null && args.length == 1) {
            content = "Получено одно значение: " + args[0];
        }

        System.out.println("Sender отправляет:\n" + content);
        
        final String finalContent = content;

        addBehaviour(new OneShotBehaviour() {
            @Override
            public void action() {
                ACLMessage msg = new ACLMessage(ACLMessage.INFORM);
                msg.setContent(finalContent);
                msg.addReceiver(new AID("SecondAgent", AID.ISLOCALNAME));
                send(msg);
                System.out.println("=== Сообщение отправлено! ===");
            }
        });
    }
}