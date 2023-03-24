import { CreateAccount } from '../repositories/AccountRepository/AccountRepository.js';
import { GenerateNotification, GenerateSuccessNotification } from '../components/Notifications/NotificationContainer.js';


export async function CreateAccountUseCase(username, password, name, lastName, email, confirmPassword)
{
    let notifications = [];

    if(username === "" || password === "" || name === "" || lastName === "" || email === "" || confirmPassword === ""){
        notifications.push(GenerateNotification("É necessário que todos os campos estejam preenchidos."));
        return notifications;
    }

    if(password !== confirmPassword){
        notifications.push(GenerateNotification("A confirmação de senha não coincide com a respectiva senha."));
        return notifications;
    }
    
    let createAccountResult = await CreateAccount(username, name, lastName, email, password, confirmPassword);
    
    createAccountResult.forEach(notification => {
        notifications.push(notification);
    })

    return notifications;   
}