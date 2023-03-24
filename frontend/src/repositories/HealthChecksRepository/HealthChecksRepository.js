import axios from "axios";
import { Endpoint } from "../Endpoint";
import { GenerateNotification, GenerateSuccessNotification } from "../../components/Notifications/NotificationContainer";

const healthCheckEndpoint = Endpoint + "api/gateway/v1/management/healthchecks/";

export async function GetHealthChecksInformationAsync(){
    let notifications = [];
    let services = [];

    try
    {
        await axios.get(healthCheckEndpoint + "readinesscheck").then(response => {
            notifications.push(GenerateSuccessNotification("A saúde do servidor é válido para funcionamento."));
            return { Notifications: notifications, Services: response.data.Services };
        }).catch(error => {
            if(error.request.status !== 0){
                if(error.response.status === 400){
                    notifications.push(GenerateNotification("A saúde do servidor não é boa, certos recursos estão funcionando com um fluxo de trabalho diferente."));
                    error.response.data.forEach(element => {
                        services.push( { ServiceVersion: element.serviceVersion, ServiceDescription: element.serviceDescription,
                        ServiceName: element.serviceName, ServiceIsReady: element.serviceIsReady});
                    });
                    return { Notifications: notifications, Services: services };
                }else{
                    notifications.push(GenerateNotification("Não foi possível buscar as informações de saúde do servidor."));
                    return { Notifications: notifications, Services: error.response.data };
                }
            }

            console.log(error);
            notifications.push(GenerateNotification("A saúde do servidor não é boa, certos recursos estão funcionando com um fluxo de trabalho diferente."));
            return { Notifications: notifications, Services: services };
        });
    }
    catch
    {
        notifications.push(GenerateNotification("Não foi possível buscar as informações de saúde do servidor."));
        return { Notifications: notifications, Services: services };
    }

    return { Notifications: notifications, Services: services };
}