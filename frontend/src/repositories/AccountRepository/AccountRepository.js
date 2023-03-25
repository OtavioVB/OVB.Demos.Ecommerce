import { Endpoint } from "../Endpoint";
import axios from "axios";
import { ProjectTenantIdentifier, ProjectSourcePlatform } from "../../configuration/ProjectConfiguration";
import { GenerateNotification, GenerateSuccessNotification } from "../../components/Notifications/NotificationContainer";

const AccountControllerEndpoint = Endpoint + "api/gateway/v1/management/account/";

export async function CreateAccount(username, name, lastName, email, password, confirmPassword){
    let notifications = [];

    await axios.post(AccountControllerEndpoint + "create", {
        username: username,
        name: name, 
        lastName: lastName,
        email: email,
        password: password,
        confirmPassword: confirmPassword,
        tenantIdentifier: ProjectTenantIdentifier,
        sourcePlatform: ProjectSourcePlatform
    }).then(response => {
        if(response.status === 201 || response.status === 200)
        {
            notifications.push(GenerateSuccessNotification("Cadastro realizado com sucesso!"));
            return notifications;
        }
        else if(response.status === 400 || response.status === 422)
        {
            response.data.forEach(element => {
                notifications.push(GenerateNotification(element));
            });
            return notifications;
        }
    }).catch(error => {
        if(error.request.status !== 0){
            if(error.response.status === 422 || error.response.status === 400)
            {
                error.response.data.forEach(element => {
                    notifications.push(GenerateNotification(element));
                });
                return notifications;
            }
            else
            {
                notifications.push(GenerateNotification("Não foi possível logar em sua conta, erro interno do sistema de conexão e integração com a api de processamento de dados, contate o suporte."));
                return notifications;
            }
        }
        else
        {
            notifications.push(GenerateNotification("Contate o suporte. Não foi possível logar em sua conta, erro interno do sistema de conexão e integração com a api de processamento de dados."));
            return notifications;
        }
    })

    return notifications;
}