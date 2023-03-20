import { CreateAccount } from '../repositories/AccountRepository/AccountRepository.js';
import { v4 as uuidv4 } from 'uuid';


export function CreateAccountUseCase(username, password, name, lastName, email, confirmPassword)
{
    let notifications = [];

    if(username === "" || password === "" || name === "" || lastName === "" || email === "" || confirmPassword === ""){
        notifications.push(GenerateNotification("É necessário que todos os campos estejam preenchidos."));
    }

    if(password !== confirmPassword){
        notifications.push(GenerateNotification("A confirmação de senha não coincide com a respectiva senha."));
    }
    
    let createAccountResponse = CreateAccount(username, name, lastName, email, password, confirmPassword);

    createAccountResponse.forEach(notification => {
        notifications.push({ Text: notification.Text, Id: notification.Id });
    });
    
    return notifications;   
}

function GenerateNotification(text){
    return { Text: text, Id: uuidv4() };
}