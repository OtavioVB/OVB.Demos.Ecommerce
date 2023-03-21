import styles from './ServerStatus.module.css';
import Header from '../../../sections/Header/Header';
import { Fragment } from 'react';

export default function ServerStatus(){
    return (
        <Fragment>
            <Header></Header>
            <main className={styles.MainStatus}>
                <section className={styles.SectionServices}>
                    <div className={styles.ServiceComponent}>
                        <div className={styles.ServiceComponentContent}>
                            <h1 className={styles.ServiceComponentTitle}>Microsserviço de Conta - PostgreeSQL</h1>
                            <div className={styles.ServiceComponentCredentials}>
                                <p className={styles.ServiceComponentStatus}><b className={styles.Healthy}>Healthy</b></p>
                                <p className={styles.ServiceComponentVersion}><b>15.2.0</b></p>
                            </div>
                        </div>
                        <p className={styles.ServiceComponentDescription}>Sistema de gerenciamento de banco de dados para acesso e armazenamento de dados da aplicação.</p>
                    </div>
                    <div className={styles.ServiceComponent}>
                        <div className={styles.ServiceComponentContent}>
                            <h1 className={styles.ServiceComponentTitle}>Microsserviço de Conta - RabbitMQ</h1>
                            <div className={styles.ServiceComponentCredentials}>
                                <p className={styles.ServiceComponentStatus}><b className={styles.Healthy}>Healthy</b></p>
                                <p className={styles.ServiceComponentVersion}><b>6.21.0</b></p>
                            </div>
                        </div>
                        <p className={styles.ServiceComponentDescription}>Sistema de gerenciamento de banco de dados para acesso e armazenamento de dados da aplicação.</p>
                    </div>
                    <div className={styles.ServiceComponent}>
                        <div className={styles.ServiceComponentContent}>
                            <h1 className={styles.ServiceComponentTitle}>Microsserviço de Conta - Redis</h1>
                            <div className={styles.ServiceComponentCredentials}>
                                <p className={styles.ServiceComponentStatus}><b className={styles.Healthy}>Healthy</b></p>
                                <p className={styles.ServiceComponentVersion}><b>3.02.17</b></p>
                            </div>
                        </div>
                        <p className={styles.ServiceComponentDescription}>Sistema de gerenciamento de banco de dados para acesso e armazenamento de dados da aplicação.</p>
                    </div>
                </section>
            </main>
        </Fragment>
        );
}