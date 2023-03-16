import './Header.css';
import React from 'react';

export default function Header(){
    React.useEffect(() => {

        let isCategoryListOpened = false;
        document.getElementById("category-ul-new-list").addEventListener("click", () => {
            if(isCategoryListOpened === false){
                isCategoryListOpened = true;
                const contentList = document.getElementById("category-ul-new-list-content");
                document.getElementById("support-icon").style = "transform: rotate(90deg);";
                contentList.style = "display: flex;";
            }
            else
            {
                isCategoryListOpened = false;
                const contentList = document.getElementById("category-ul-new-list-content");
                document.getElementById("support-icon").style = "transform: rotate(0deg);";
                contentList.style = "display: none;";
            }
        });
    });

    return (
    <header>
        <div class="header-ecommerce-content">
            <div class="header-ecommerce-content-title-definition">
                <h1 class="header-ecommerce-content-title-definition-value"><strong>Ecommerce</strong></h1>
                <span class="separator"></span>
            </div>
            <div class="header-ecommerce-content-navigation">
                <nav class="header-ecommerce-content-navigation-nav">
                    <ul class="header-ecommerce-content-navigation-nav-content-list">
                        <li class="header-ecommerce-content-navigation-nav-content-list-item">
                            <a href="https://google.com.br" class="header-ecommerce-content-navigation-nav-content-list-link">Ofertas</a>
                        </li>
                        <li id="category-ul-new-list" class="header-ecommerce-content-navigation-nav-content-list-item">
                            <p class="header-ecommerce-content-navigation-nav-content-list-link">Categorias <svg id="support-icon" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-caret-right" viewBox="0 0 16 16"><path d="M6 12.796V3.204L11.481 8 6 12.796zm.659.753 5.48-4.796a1 1 0 0 0 0-1.506L6.66 2.451C6.011 1.885 5 2.345 5 3.204v9.592a1 1 0 0 0 1.659.753z"/></svg></p>
                            <ul id="category-ul-new-list-content" class="header-ecommerce-content-navigation-nav-content-list-category">
                                <li class="header-ecommerce-content-navigation-nav-content-list-category-item">
                                    <a href="https://google.com.br" class="header-ecommerce-content-navigation-nav-content-list-category-item-link">Tecnologia</a>
                                </li>
                                <li class="header-ecommerce-content-navigation-nav-content-list-category-item">
                                    <a href="https://google.com.br" class="header-ecommerce-content-navigation-nav-content-list-category-item-link">Veículos</a>
                                </li>
                                <li class="header-ecommerce-content-navigation-nav-content-list-category-item">
                                    <a href="https://google.com.br" class="header-ecommerce-content-navigation-nav-content-list-category-item-link">Construção</a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </nav>
                <span class="separator"></span>
            </div>
            <div class="header-ecommerce-content-account">
                <a class="header-ecommerce-content-account-link" href="https://google.com.br">Entrar</a>
            </div>
        </div>
    </header>
    );
}