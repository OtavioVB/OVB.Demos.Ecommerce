import { Endpoint } from "../Endpoint";
import axios from "axios";
import { v4 as uuidv4 } from 'uuid';
import { ProjectTenantIdentifier, ProjectSourcePlatform } from "../../configuration/ProjectConfiguration";

const AccountControllerEndpoint = Endpoint + "api/gateway/v1/management/account/";

export function CreateAccount(username, name, lastName, email, password, confirmPassword){
    let notifications = [];

    try
    {
        axios.post(AccountControllerEndpoint + "Create", {
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

            }
            else
            {
                notifications.push(GenerateNotification("Não foi possível logar em sua conta, erro interno do sistema de conexão e integração com a api de processamento de dados, contate o suporte."));
            }
        }).catch(error => {
            if(error.response.status === 400)
            {

            }
            else
            {
                notifications.push(GenerateNotification("Não foi possível logar em sua conta, erro interno do sistema de conexão e integração com a api de processamento de dados, contate o suporte."));
            }
            return notifications;
        })
    }
    catch
    {
        notifications.push(GenerateNotification("Não foi possível logar em sua conta, erro interno do sistema de conexão e integração com a api de processamento de dados, contate o suporte."));
        return notifications;
    }
}

function GenerateNotification(text){
    return { Text: text, Id: uuidv4() };
}