import styles from './Footer.module.css';
import SeparatorHorizontal from "../../components/Separator/SeparatorHorizontal/SeparatorHorizontal";

export default function Footer(){
    return (
        <div className={styles.FooterArea}>
            <SeparatorHorizontal Text="Contribuidores"></SeparatorHorizontal>
            <p className={styles.FooterCopyright}>Copyright &copy; 2023 - Ecommerce | Desenvolvido com &#128156; por 
            <a className={styles.FooterAuthor} href="https://www.linkedin.com/in/otaviovillasboassimoncinicarmanini/"><b className={styles.FooterBolder}> Otávio Villas Boas Simoncini Carmanini</b></a></p>
        </div>
    );
}