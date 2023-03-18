import HeaderWithoutNav from '../../../../sections/Header/HeaderWithoutNav.js';
import styles from './MemberCreate.module.css';
import SeparatorHorizontal from '../../../../components/Separator/SeparatorHorizontal/SeparatorHorizontal.js';
import FormItem from '../../../../components/Form/FormItem/FormItem.js';
import FormSubmitItem from '../../../../components/Form/FormSubmitItem/FormSubmitItem.js';
import { Fragment, useState } from 'react';
import Footer from '../../../../sections/Footer/Footer.js';
import React from 'react';
/* import CreateAccount from '../../../../repositories/AccountRepository/AccountRepository.js';
import { ProjectSourcePlatform, ProjectTenantIdentifier } from '../../../../configuration/ProjectConfiguration.js'; */

export default function MemberCreate(){
    const [username, setUsername] = useState("");
    const [name, setName] = useState("");
    const [lastName, setLastName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [notifications, setNotifications] = useState([]);

    function addNotification(notification){
        setNotifications(oldList => [...oldList, notification])
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
                    <FormSubmitItem OnClick={() => { addNotification("teste"); }}Identifier="submit-form" Value="Cadastrar-se"></FormSubmitItem>
                    {
                        notifications.map(notification => {
                            return (
                                <p>{notification}</p>
                            );
                        })
                    }
                    <Footer WithContact={true}></Footer>
                </section>
            </main>
        </Fragment>
        );
}