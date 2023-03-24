import styles from './ServerStatus.module.css';
import Header from '../../../sections/Header/Header';
import { Fragment, useState } from 'react';
import { NotificationContainer } from '../../../components/Notifications/NotificationContainer.js';
import stylesNotification from '../../../components/Notifications/NotificationContainer.module.css';
import { GetHealthChecksAsync } from '../../../usecases/HealthChecksUseCases.js';
import { v4 as uuidv4 } from 'uuid';

export default function ServerStatus(){
    const [notifications, setNotifications] = useState([]);
    const [services, setServices] = useState([]);

    function removeNotification(id){
        setNotifications(oldList => oldList.filter(item => item.Id !== id));
    }

    async function GetHealthChecks(){
        var result = await GetHealthChecksAsync();
        setNotifications(result.Notifications);
        setServices(result.Services);
    }

    GetHealthChecks();

    return (
        <Fragment>
            <Header></Header>
            <main className={styles.MainStatus}>
                <section className={styles.SectionServices}>
                    {
                        services.map(service => {
                            if(service.ServiceIsReady === "Unhealthy"){
                                return (
                                <div key={uuidv4()} className={styles.ServiceComponent}>
                                    <div className={styles.ServiceComponentContent}>
                                        <h1 className={styles.ServiceComponentTitle}>{service.ServiceName}</h1>
                                        <div className={styles.ServiceComponentCredentials}>
                                            <p className={styles.ServiceComponentStatus}><b className={styles.Unhealthy}>{service.ServiceIsReady}</b></p>
                                            <p className={styles.ServiceComponentVersion}><b>{service.ServiceVersion}</b></p>
                                        </div>
                                    </div>
                                    <p className={styles.ServiceComponentDescription}>{service.ServiceDescription}</p>
                                </div> );
                            }else
                            {
                                return (
                                <div key={uuidv4()} className={styles.ServiceComponent}>
                                    <div className={styles.ServiceComponentContent}>
                                        <h1 className={styles.ServiceComponentTitle}>{service.ServiceName}</h1>
                                        <div className={styles.ServiceComponentCredentials}>
                                            <p className={styles.ServiceComponentStatus}><b className={styles.Healthy}>{service.ServiceIsReady}</b></p>
                                            <p className={styles.ServiceComponentVersion}><b>{service.ServiceVersion}</b></p>
                                        </div>
                                    </div>
                                    <p className={styles.ServiceComponentDescription}>{service.ServiceDescription}</p>
                                </div> );
                            }
                        })
                    }
                </section>
                <NotificationContainer>
                    {
                        notifications.map(notification => {
                            if(notification.Type === "Error")
                            {
                                return (
                                    <div key={notification.Id} onClick={() => { removeNotification(notification.Id); }} className={stylesNotification.NotificationContainerItem}>
                                        <h1 className={stylesNotification.NotificationContainerItemTitle}>Erro</h1>
                                        <p className={stylesNotification.NotificationContainerItemDescription}>{notification.Text}</p>
                                    </div>
                                )
                            }
                            else
                            {
                                return (
                                    <div key={notification.Id} onClick={() => { removeNotification(notification.Id); }} className={stylesNotification.NotificationContainerItemSuccess}>
                                        <h1 className={stylesNotification.NotificationContainerItemTitle}>Sucesso</h1>
                                        <p className={stylesNotification.NotificationContainerItemDescription}>{notification.Text}</p>
                                    </div>
                                )
                            }
                        })
                    }
                </NotificationContainer>
            </main>
        </Fragment>
        );
}