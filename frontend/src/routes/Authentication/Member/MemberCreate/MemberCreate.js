import HeaderWithoutNav from '../../../../sections/Header/HeaderWithoutNav.js';
import styles from './MemberCreate.module.css';
import SeparatorHorizontal from '../../../../components/Separator/SeparatorHorizontal/SeparatorHorizontal.js';
import FormItem from '../../../../components/Form/FormItem/FormItem.js';
import FormSubmitItem from '../../../../components/Form/FormSubmitItem/FormSubmitItem.js';
import { Fragment } from 'react';
import Footer from '../../../../sections/Footer/Footer.js';

export default function MemberCreate(){
    return (
        <Fragment>
            <HeaderWithoutNav></HeaderWithoutNav>
            <main class={styles.MainContent}>
                <section class={styles.Container}>
                    <h1 class={styles.Title}>Criar conta como membro</h1>
                    <SeparatorHorizontal Text="Informação pessoal"></SeparatorHorizontal>
                    <FormItem Placeholder="Insira seu nome" Identifier="name" Text="Nome" TypeInput="text"></FormItem>
                    <FormItem Placeholder="Insira seu sobrenome" Identifier="lastname" Text="Sobrenome" TypeInput="text"></FormItem>
                    <SeparatorHorizontal Text="Credenciais"></SeparatorHorizontal>
                    <FormItem Placeholder="Insira seu nome de usuário" Identifier="username" Text="Nome de Usuário" TypeInput="text"></FormItem>
                    <FormItem Placeholder="Insira seu email" Identifier="email" Text="Email" TypeInput="email"></FormItem>
                    <FormItem Placeholder="Insira sua senha" Identifier="password" Text="Senha" TypeInput="password"></FormItem>
                    <FormItem Placeholder="Insira sua confirmação de senha" Identifier="password" Text="Confirme sua Senha" TypeInput="password"></FormItem>
                    <FormSubmitItem Identifier="submit-form" Value="Cadastrar-se"></FormSubmitItem>
                    <Footer></Footer>
                </section>
            </main>
        </Fragment>
        );
}