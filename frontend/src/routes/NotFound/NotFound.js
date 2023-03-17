import './NotFound.css';
import { Link } from 'react-router-dom';

export default function NotFound(){
    return (
            <main class="notfound-main">
                <h1 className='notfound-error-title'>ERROR 404</h1>
                <p className='notfound-error-description'>Não foi possível encontrar a página esperada</p>
                <Link className='notfound-component-redirect-other-link' to="/">Voltar para página inicial</Link>
            </main>
        );
}