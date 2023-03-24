import axios from "axios";
import { Endpoint } from "../Endpoint";
import { GenerateNotification, GenerateSuccessNotification } from "../../components/Notifications/NotificationContainer";

const healthCheckEndpoint = Endpoint + "api/gateway/v1/management/healthchecks/";

export async function GetHealthChecksInformationAsync(){
    let notifications = [];

    try
    {
        await axios.get(healthCheckEndpoint + "readinesscheck").then(response => {
            console.log(response.data);
            notifications.push(GenerateSuccessNotification("A saúde do servidor é válido para funcionamento."));
            return { Notifications: notifications, Services: response.data.Services };
        }).catch(error => {
            if(error.request.status !== 0){
                if(error.response.status === 500){
                    notifications.push(GenerateNotification("Não foi possível buscar as informações de saúde do servidor."));
                    return { Notifications: notifications, Services: [] };
                }
            }

            console.log(error);
            notifications.push(GenerateNotification("A saúde do servidor não é boa, certos recursos estão funcionando com um fluxo de trabalho diferente."));
            return { Notifications: notifications, Services: [] };
        });
    }
    catch
    {
        notifications.push(GenerateNotification("Não foi possível buscar as informações de saúde do servidor."));
        return { Notifications: notifications, Services: [] };
    }

    return { Notifications: notifications, Services: [] };
}