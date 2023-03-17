import './LandingPage.css';
import { Fragment } from 'react';
import Header from '../../sections/Header/Header.js';
import React from 'react';

export default function LandingPage(){
    React.useEffect(() => {
        const itemsQuantity = 7;
        let itemIndex = 4;
        let translateLength = 0;

        document.getElementById("next-icon").addEventListener("click", () => {
            if(itemIndex < itemsQuantity){
                translateLength -= 244;
                document.getElementById("allcontent").style = "transform: translateX(" + translateLength + "px);";
                itemIndex++;
            }
        });

        document.getElementById("back-icon").addEventListener("click", () => {
            if(itemIndex > 0){
                translateLength += 244;
                document.getElementById("allcontent").style = "transform: translateX(" + translateLength + "px);";
                itemIndex--;
            }
        });
    });
    return (
        <Fragment>
            <Header></Header>
            <main>
                <p class="quantity-of-users">Atualmente, somos uma plataforma com <b>1 usuários</b> ativos. &#127919;</p>
                <section class="section-view-most-popular-products">
                    <div class="section-view-most-popular-products-content">
                        <h1 class="section-view-most-popular-products-content-title">Ofertas &#128184;</h1>
                        <div class="section-view-most-popular-products-content-carrousel">
                            <div id="allcontent" class="section-view-most-popular-products-content-carrousel-allcontent">
                                <div class="section-view-most-popular-products-content-carrousel-product-information">
                                    <img src="https://electrolux.vtexassets.com/arquivos/ids/202276/geladeira-refrigerador-branca-472-litros--tc56--_Detalhe2.png?v=637691473178370000" alt="" class="section-view-most-popular-products-content-carrousel-product-information-image"></img>
                                    <h1 class="section-view-most-popular-products-content-carrousel-product-information-title">Geladeira 1</h1>
                                    <div class="section-view-most-popular-products-content-carrousel-product-information-discount">
                                        <strong class="section-view-most-popular-products-content-carrousel-product-information-discount-value">R$ 2.5432,00</strong>
                                        <p class="section-view-most-popular-products-content-carrousel-product-information-discount-value-porcentage">26% OFF</p>
                                    </div>
                                    <p class="section-view-most-popular-products-content-carrousel-product-information-discount-description">Geladeira Electrolux 120L 127V</p>
                                </div>
                                <div class="section-view-most-popular-products-content-carrousel-product-information">
                                    <img src="https://electrolux.vtexassets.com/arquivos/ids/202276/geladeira-refrigerador-branca-472-litros--tc56--_Detalhe2.png?v=637691473178370000" alt="" class="section-view-most-popular-products-content-carrousel-product-information-image"></img>
                                    <h1 class="section-view-most-popular-products-content-carrousel-product-information-title">Geladeira 2</h1>
                                    <div class="section-view-most-popular-products-content-carrousel-product-information-discount">
                                        <strong class="section-view-most-popular-products-content-carrousel-product-information-discount-value">R$ 2.5432,00</strong>
                                        <p class="section-view-most-popular-products-content-carrousel-product-information-discount-value-porcentage">26% OFF</p>
                                    </div>
                                    <p class="section-view-most-popular-products-content-carrousel-product-information-discount-description">Geladeira Electrolux 120L 127V</p>
                                </div>
                                <div class="section-view-most-popular-products-content-carrousel-product-information">
                                    <img src="https://electrolux.vtexassets.com/arquivos/ids/202276/geladeira-refrigerador-branca-472-litros--tc56--_Detalhe2.png?v=637691473178370000" alt="" class="section-view-most-popular-products-content-carrousel-product-information-image"></img>
                                    <h1 class="section-view-most-popular-products-content-carrousel-product-information-title">Geladeira 3</h1>
                                    <div class="section-view-most-popular-products-content-carrousel-product-information-discount">
                                        <strong class="section-view-most-popular-products-content-carrousel-product-information-discount-value">R$ 2.5432,00</strong>
                                        <p class="section-view-most-popular-products-content-carrousel-product-information-discount-value-porcentage">26% OFF</p>
                                    </div>
                                    <p class="section-view-most-popular-products-content-carrousel-product-information-discount-description">Geladeira Electrolux 120L 127V</p>
                                </div>
                                <div class="section-view-most-popular-products-content-carrousel-product-information">
                                    <img src="https://electrolux.vtexassets.com/arquivos/ids/202276/geladeira-refrigerador-branca-472-litros--tc56--_Detalhe2.png?v=637691473178370000" alt="" class="section-view-most-popular-products-content-carrousel-product-information-image"></img>
                                    <h1 class="section-view-most-popular-products-content-carrousel-product-information-title">Geladeira 4</h1>
                                    <div class="section-view-most-popular-products-content-carrousel-product-information-discount">
                                        <strong class="section-view-most-popular-products-content-carrousel-product-information-discount-value">R$ 2.5432,00</strong>
                                        <p class="section-view-most-popular-products-content-carrousel-product-information-discount-value-porcentage">26% OFF</p>
                                    </div>
                                    <p class="section-view-most-popular-products-content-carrousel-product-information-discount-description">Geladeira Electrolux 120L 127V</p>
                                </div>
                                <div class="section-view-most-popular-products-content-carrousel-product-information">
                                    <img src="https://electrolux.vtexassets.com/arquivos/ids/202276/geladeira-refrigerador-branca-472-litros--tc56--_Detalhe2.png?v=637691473178370000" alt="" class="section-view-most-popular-products-content-carrousel-product-information-image"></img>
                                    <h1 class="section-view-most-popular-products-content-carrousel-product-information-title">Geladeira 5</h1>
                                    <div class="section-view-most-popular-products-content-carrousel-product-information-discount">
                                        <strong class="section-view-most-popular-products-content-carrousel-product-information-discount-value">R$ 2.5432,00</strong>
                                        <p class="section-view-most-popular-products-content-carrousel-product-information-discount-value-porcentage">26% OFF</p>
                                    </div>
                                    <p class="section-view-most-popular-products-content-carrousel-product-information-discount-description">Geladeira Electrolux 120L 127V</p>
                                </div>
                                <div class="section-view-most-popular-products-content-carrousel-product-information">
                                    <img src="https://electrolux.vtexassets.com/arquivos/ids/202276/geladeira-refrigerador-branca-472-litros--tc56--_Detalhe2.png?v=637691473178370000" alt="" class="section-view-most-popular-products-content-carrousel-product-information-image"></img>
                                    <h1 class="section-view-most-popular-products-content-carrousel-product-information-title">Geladeira 6</h1>
                                    <div class="section-view-most-popular-products-content-carrousel-product-information-discount">
                                        <strong class="section-view-most-popular-products-content-carrousel-product-information-discount-value">R$ 2.5432,00</strong>
                                        <p class="section-view-most-popular-products-content-carrousel-product-information-discount-value-porcentage">26% OFF</p>
                                    </div>
                                    <p class="section-view-most-popular-products-content-carrousel-product-information-discount-description">Geladeira Electrolux 120L 127V</p>
                                </div>
                                <div class="section-view-most-popular-products-content-carrousel-product-information">
                                    <img src="https://electrolux.vtexassets.com/arquivos/ids/202276/geladeira-refrigerador-branca-472-litros--tc56--_Detalhe2.png?v=637691473178370000" alt="" class="section-view-most-popular-products-content-carrousel-product-information-image"></img>
                                    <h1 class="section-view-most-popular-products-content-carrousel-product-information-title">Geladeira 7</h1>
                                    <div class="section-view-most-popular-products-content-carrousel-product-information-discount">
                                        <strong class="section-view-most-popular-products-content-carrousel-product-information-discount-value">R$ 2.5432,00</strong>
                                        <p class="section-view-most-popular-products-content-carrousel-product-information-discount-value-porcentage">26% OFF</p>
                                    </div>
                                    <p class="section-view-most-popular-products-content-carrousel-product-information-discount-description">Geladeira Electrolux 120L 127V</p>
                                </div>
                            </div>
                            <svg id="next-icon" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-down-circle-fill" viewBox="0 0 16 16"><path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8.5 4.5a.5.5 0 0 0-1 0v5.793L5.354 8.146a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l3-3a.5.5 0 0 0-.708-.708L8.5 10.293V4.5z"/></svg>
                                <svg id="back-icon" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-down-circle-fill" viewBox="0 0 16 16"><path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8.5 4.5a.5.5 0 0 0-1 0v5.793L5.354 8.146a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0l3-3a.5.5 0 0 0-.708-.708L8.5 10.293V4.5z"/></svg>
                        </div>
                    </div>
                </section>
            </main>
        </Fragment>
    );
}