import './Header.css';
import React from 'react';
import { Link } from 'react-router-dom';

export default function HeaderWithoutNav(){
    return (
        <header>
            <div className="header-ecommerce-content">
                <div className="header-ecommerce-content-title-definition">
                    <h1 className="header-ecommerce-content-title-definition-value"><strong><Link className="header-ecommerce-content-title-definition-value-link" to="/">Ecommerce</Link></strong></h1>
                    <span className="separator"></span>
                </div>
                <div className="header-ecommerce-content-account">
                    <Link className="header-ecommerce-content-account-link" to="/authentication">Voltar</Link>
                </div>
            </div>
        </header>
    );
}