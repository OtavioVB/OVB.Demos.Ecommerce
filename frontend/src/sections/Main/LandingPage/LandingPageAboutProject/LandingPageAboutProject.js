import styles from './LandingPageAboutProject.module.css';

export default function LandingPageAboutProject(){
    return (
    <section class={styles.LandingPageAboutProject}>
        <div class={styles.TitleContent}>
            <h1 class={styles.Title}>Sobre o projeto</h1>
            <p class={styles.Text}>A intenção desse projeto desse projeto é desenvolver um <strong>Ecommerce</strong></p>
        </div>
    </section>
    );
}