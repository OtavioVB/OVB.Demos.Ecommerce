import HeaderWithoutNav from '../../../../sections/Header/HeaderWithoutNav.js';
import styles from './MemberCreate.module.css';
import SeparatorHorizontal from '../../../../components/Separator/SeparatorHorizontal/SeparatorHorizontal.js';
import FormItem from '../../../../components/Form/FormItem/FormItem.js';
import FormSubmitItem from '../../../../components/Form/FormSubmitItem/FormSubmitItem.js';
import { Fragment } from 'react';
import Footer from '../../../../sections/Footer/Footer.js';
import React from 'react';
/* import CreateAccount from '../../../../repositories/AccountRepository/AccountRepository.js';
import { ProjectSourcePlatform, ProjectTenantIdentifier } from '../../../../configuration/ProjectConfiguration.js'; */

export default function MemberCreate(){
    React.useEffect(() => {
        document.getElementById("submit-form").addEventListener("click", () =>
        {
            /* 
            let username = document.getElementById("username").value;
            let name = document.getElementById("name").value;
            let lastName = document.getElementById("lastName").value;
            let email = document.getElementById("email").value;
            let password = document.getElementById("password").value;
            let confirmPassword = document.getElementById("confirmPassword").value;

            CreateAccount(username, name, lastName, email, password, confirmPassword, ProjectTenantIdentifier, ProjectSourcePlatform);*/
        });
    });

    return (
        <Fragment>
            <HeaderWithoutNav></HeaderWithoutNav>
            <main className={styles.MainContent}>
                <section className={styles.Container}>
                    <h1 className={styles.Title}>Criar conta como membro</h1>
                    <SeparatorHorizontal Text="Informação pessoal"></SeparatorHorizontal>
                    <FormItem Placeholder="Insira seu nome" Identifier="name" Text="Nome" TypeInput="text"></FormItem>
                    <FormItem Placeholder="Insira seu sobrenome" Identifier="lastname" Text="Sobrenome" TypeInput="text"></FormItem>
                    <SeparatorHorizontal Text="Credenciais"></SeparatorHorizontal>
                    <FormItem Placeholder="Insira seu nome de usuário" Identifier="username" Text="Nome de Usuário" TypeInput="text"></FormItem>
                    <FormItem Placeholder="Insira seu email" Identifier="email" Text="Email" TypeInput="email"></FormItem>
                    <FormItem Placeholder="Insira sua senha" Identifier="password" Text="Senha" TypeInput="password"></FormItem>
                    <FormItem Placeholder="Insira sua confirmação de senha" Identifier="confirmPassword" Text="Confirme sua Senha" TypeInput="password"></FormItem>
                    <FormSubmitItem Identifier="submit-form" Value="Cadastrar-se"></FormSubmitItem>
                    <Footer WithContact={true}></Footer>
                </section>
            </main>
        </Fragment>
        );
}