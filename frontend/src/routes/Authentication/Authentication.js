import './Authentication.css';
import SeparatorHorizontal from '../../components/separator/SeparatorHorizontal/SeparatorHorizontal';
import { Fragment } from 'react';
import FormItem from '../../components/form/FormItem/FormItem.js';
import FormSubmitItem from '../../components/form/FormSubmitItem/FormSubmitItem';
import ButtonRedirection from '../../components/Redirections/ButtonRedirection/ButtonRedirection';
import React from 'react';

export default function Authentication(){
    React.useEffect(() => {
        document.getElementById("submit-form").addEventListener("click", () => {
            let inputUsername = document.getElementById("username");
            console.log(inputUsername.value);
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
                    <ButtonRedirection Href="https://google.com.br" Value="Entrar como empresa"></ButtonRedirection>
                    <SeparatorHorizontal Text="Ainda não tem uma conta?"></SeparatorHorizontal>
                    <ButtonRedirection Href="https://google.com.br" Value="Criar conta como empresa"></ButtonRedirection>
                    <ButtonRedirection Href="https://google.com.br" Value="Criar conta como membro"></ButtonRedirection>
                    <div className="authentication-main-distribution-form-area-footer">
                        <SeparatorHorizontal Text="Contribuidores"></SeparatorHorizontal>
                        <p className="authentication-main-distribution-form-area-footer-text">Copyright &copy; 2023 - Ecommerce | Desenvolvido com &#128156; por 
                        <a className="authentication-main-distribution-form-area-footer-text-bold-author-reference" href="https://www.linkedin.com/in/otaviovillasboassimoncinicarmanini/"><b className="authentication-main-distribution-form-area-footer-text-bold"> Otávio Villas Boas Simoncini Carmanini</b></a></p>
                    </div>
                </div>
                <div className="authentication-main-distribution-content">
                    <img className="authentication-main-distribution-content-image" alt="" src='/assets/imgs/business.jfif'></img>
                </div>
            </main>
        </Fragment>
    );
}