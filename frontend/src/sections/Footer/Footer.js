import styles from './Footer.module.css';
import SeparatorHorizontal from "../../components/Separator/SeparatorHorizontal/SeparatorHorizontal";
import { ProjectAboutMessage, ProjectAuthor, ProjectName, ProjectYear } from "../../configuration/ProjectConfiguration.js";
import { Fragment } from 'react';

export default function Footer({WithContact}){
    if(WithContact == null || WithContact === false){
        return (
            <Fragment>
                <div className={styles.FooterArea}>
                    <SeparatorHorizontal Text="Contribuidores"></SeparatorHorizontal>
                    <p className={styles.FooterCopyright}>Copyright &copy; {ProjectYear} - {ProjectName} | Desenvolvido com &#128156; por 
                    <a className={styles.FooterAuthor} href="https://www.linkedin.com/in/otaviovillasboassimoncinicarmanini/"><b className={styles.FooterBolder}> {ProjectAuthor}</b></a></p>
                </div>
            </Fragment>
        );
    }else{
        return (
            <Fragment>
                <div className={styles.ContactContainer}>
                    <SeparatorHorizontal Text="Sobre"></SeparatorHorizontal>
                    <p className={styles.ContactAboutText}>{ProjectAboutMessage}</p>
                </div>
                <div className={styles.FooterAreaWithoutHeight}>
                    <SeparatorHorizontal Text="Contribuidores"></SeparatorHorizontal>
                    <p className={styles.FooterCopyright}>Copyright &copy; {ProjectYear} - {ProjectName} | Desenvolvido com &#128156; por 
                    <a className={styles.FooterAuthor} href="https://www.linkedin.com/in/otaviovillasboassimoncinicarmanini/"><b className={styles.FooterBolder}> {ProjectAuthor}</b></a></p>
                </div>
            </Fragment>
        );
    }
}