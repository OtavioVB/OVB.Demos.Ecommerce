import './Authentication.css';
import SeparatorHorizontal from '../../components/separator/SeparatorHorizontal/SeparatorHorizontal';
import { Fragment } from 'react';
import FormItem from '../../components/form/FormItem/FormItem.js';
import FormSubmitItem from '../../components/form/FormSubmitItem/FormSubmitItem';
import ButtonRedirection from '../../components/Redirections/ButtonRedirection/ButtonRedirection';

export default function Authentication(){
    return (
        <Fragment>
            <main class="authentication-main-distribution">
                <div class="authentication-main-distribution-form-area">
                    <h1 class="authentication-main-distribution-content-title">Ecommerce</h1>
                    <SeparatorHorizontal Text="Entrar agora mesmo"></SeparatorHorizontal>
                    <FormItem Placeholder="Insira seu nome de usuário" Identifier="username" Text="Nome de Usuário" TypeInput="text"></FormItem>
                    <FormItem Placeholder="********" Identifier="password" Text="Senha" TypeInput="password"></FormItem>
                    <FormSubmitItem Value="Entrar agora mesmo" Identifier="submit-form"></FormSubmitItem>
                    <SeparatorHorizontal Text="ou"></SeparatorHorizontal>
                    <ButtonRedirection Href="https://google.com.br" Value="Entrar como empresa"></ButtonRedirection>
                    <SeparatorHorizontal Text="Ainda não tem uma conta?"></SeparatorHorizontal>
                    <ButtonRedirection Href="https://google.com.br" Value="Criar conta como empresa"></ButtonRedirection>
                    <ButtonRedirection Href="https://google.com.br" Value="Criar conta como membro"></ButtonRedirection>
                </div>
                <div class="authentication-main-distribution-content">
                    
                </div>
            </main>
        </Fragment>
    );
}