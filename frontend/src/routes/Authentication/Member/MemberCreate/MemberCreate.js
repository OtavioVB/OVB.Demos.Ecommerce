import HeaderWithoutNav from '../../../../sections/Header/HeaderWithoutNav.js';
import styles from './MemberCreate.module.css';
import stylesNotification from '../../../../components/Notifications/NotificationContainer.module.css';
import SeparatorHorizontal from '../../../../components/Separator/SeparatorHorizontal/SeparatorHorizontal.js';
import FormItem from '../../../../components/Form/FormItem/FormItem.js';
import FormSubmitItem from '../../../../components/Form/FormSubmitItem/FormSubmitItem.js';
import { Fragment, useState } from 'react';
import Footer from '../../../../sections/Footer/Footer.js';
import React from 'react';
import NotificationContainer from '../../../../components/Notifications/NotificationContainer.js';
import { CreateAccountUseCase } from '../../../../usecases/AccountUseCases.js';

export default function MemberCreate(){
    const [username, setUsername] = useState("");
    const [name, setName] = useState("");
    const [lastName, setLastName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [notifications, setNotifications] = useState([]);

    /*function addNotifications(notifications){
        setNotifications(oldList => oldList.concat(notifications));
    }*/

    function removeNotification(id){
        setNotifications(oldList => oldList.filter(item => item.Id !== id));
    }

    function createAccount(usernameInput, passwordInput, nameInput, lastNameInput, emailInput, confirmPasswordInput){
        let notificationsResult = CreateAccountUseCase(usernameInput, passwordInput, nameInput, lastNameInput, emailInput, confirmPasswordInput);
        setNotifications(notificationsResult);
    }

    return (
        <Fragment>
            <HeaderWithoutNav></HeaderWithoutNav>
            <main className={styles.MainContent}>
                <section className={styles.Container}>
                    <h1 className={styles.Title}>Criar conta como membro</h1>
                    <SeparatorHorizontal Text="Informação pessoal"></SeparatorHorizontal>
                    <FormItem Value={name} OnChange={e => setName(e.target.value)} Placeholder="Insira seu nome" Identifier="name" Text="Nome" TypeInput="text"></FormItem>
                    <FormItem Value={lastName} OnChange={e => setLastName(e.target.value)} Placeholder="Insira seu sobrenome" Identifier="lastname" Text="Sobrenome" TypeInput="text"></FormItem>
                    <SeparatorHorizontal Text="Credenciais"></SeparatorHorizontal>
                    <FormItem Value={username} OnChange={e => setUsername(e.target.value)} Placeholder="Insira seu nome de usuário" Identifier="username" Text="Nome de Usuário" TypeInput="text"></FormItem>
                    <FormItem Value={email} OnChange={e => setEmail(e.target.value)} Placeholder="Insira seu email" Identifier="email" Text="Email" TypeInput="email"></FormItem>
                    <FormItem Value={password} OnChange={e => setPassword(e.target.value)} Placeholder="Insira sua senha" Identifier="password" Text="Senha" TypeInput="password"></FormItem>
                    <FormItem Value={confirmPassword} OnChange={e => setConfirmPassword(e.target.value)} Placeholder="Insira sua confirmação de senha" Identifier="confirmPassword" Text="Confirme sua Senha" TypeInput="password"></FormItem>
                    <FormSubmitItem OnClick={
                        () => { 
                            createAccount(username, password, name, lastName, email, confirmPassword);
                        }} Identifier="submit-form" Value="Cadastrar-se"></FormSubmitItem>
                    
                    <NotificationContainer>
                        {
                            notifications.map(notification => {
                                return (
                                    <div key={notification.Id} onClick={() => { removeNotification(notification.Id); }} className={stylesNotification.NotificationContainerItem}>
                                        <h1 className={stylesNotification.NotificationContainerItemTitle}>Erro</h1>
                                        <p className={stylesNotification.NotificationContainerItemDescription}>{notification.Text}</p>
                                    </div>
                                )
                            })
                        }
                    </NotificationContainer>
                    <Footer WithContact={true}></Footer>
                    {
                        React.useEffect(() => {
                            for (let i = 0; i < notifications.length; i++)
                            {
                                setTimeout(() => {
                                    removeNotification(notifications[i].Id);
                                }, 2000);
                            };
                        })
                    }
                </section>
            </main>
        </Fragment>
        );
}