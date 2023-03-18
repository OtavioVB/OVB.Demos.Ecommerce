import { Endpoint } from "../Endpoint";
import axios from "axios";

const AccountControllerEndpoint = Endpoint + "api/gateway/v1/management/account/";

export default function CreateAccount(username, name, lastName, email, password, confirmPassword, tenantIdentifier, sourcePlatform){
    axios.post(AccountControllerEndpoint + "Create", {
        username: username,
        name: name, 
        lastName: lastName,
        email: email,
        password: password,
        confirmPassword: confirmPassword,
        tenantIdentifier: tenantIdentifier,
        sourcePlatform: sourcePlatform
    })
    .then(function (response) {
        if(response.status === 500){
            console.log("Internal Server Error1");
        }

        console.log(response);
    })
    .catch(() => {
        console.log("Internal Server Error2");
    });
}