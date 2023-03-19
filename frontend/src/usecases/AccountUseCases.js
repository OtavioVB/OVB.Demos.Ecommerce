
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

    if(username.length <= 4){
        notifications.push(GenerateNotification("O nome de usuário precisa conter mais que 4 caracteres."));
    }

    return notifications;   
}

function GenerateNotification(text){
    return { Text: text, Id: uuidv4() };
}