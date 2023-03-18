import './Authentication.css';
import SeparatorHorizontal from '../../components/Separator/SeparatorHorizontal/SeparatorHorizontal';
import { Fragment } from 'react';
import FormItem from '../../components/Form/FormItem/FormItem.js';
import FormSubmitItem from '../../components/Form/FormSubmitItem/FormSubmitItem';
import ButtonRedirection from '../../components/Redirections/ButtonRedirection/ButtonRedirection';
import React from 'react';
import Footer from '../../sections/Footer/Footer';

export default function Authentication(){
    React.useEffect(() => {
        document.getElementById("submit-form").addEventListener("click", () => {
            let inputUsername = document.getElementById("username");
            let inputPassword = document.getElementById("password");
            console.log(inputUsername.value);
            console.log(inputPassword.value);
        });
    });

    return (
        <Fragment>
            <main className="authentication-main-distribution">
                <div className="authentication-main-distribution-form-area">
                    <h1 className="authentication-main-distribution-content-title">Ecommerce</h1>
                    <SeparatorHorizontal Text="Entrar agora mesmo"></SeparatorHorizontal>
                    <FormItem Placeholder="Insira seu nome de usuário" Identifier="username" Text="Nome de Usuário" TypeInput="text"></FormItem>
                    <FormItem Placeholder="********" Identifier="password" Text="Senha" TypeInput="password"></FormItem>
                    <FormSubmitItem Value="Entrar agora mesmo" Identifier="submit-form"></FormSubmitItem>
                    <SeparatorHorizontal Text="ou"></SeparatorHorizontal>
                    <ButtonRedirection Href="/authentication/company/login" Value="Entrar como empresa"></ButtonRedirection>
                    <SeparatorHorizontal Text="Ainda não tem uma conta?"></SeparatorHorizontal>
                    <ButtonRedirection Href="/authentication/company/create" Value="Criar conta como empresa"></ButtonRedirection>
                    <ButtonRedirection Href="/authentication/create" Value="Criar conta como membro"></ButtonRedirection>
                    <ButtonRedirection Href="/" Value="Página Inicial"></ButtonRedirection>
                    <Footer></Footer>
                </div>
                <div className="authentication-main-distribution-content">
                    <img className="authentication-main-distribution-content-image" alt="" src='/assets/imgs/business.jfif'></img>
                </div>
            </main>
        </Fragment>
    );
}