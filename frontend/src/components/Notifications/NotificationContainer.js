import styles from './NotificationContainer.module.css';

export default function NotificationContainer({children}){
    return (
        <div className={styles.NotificationContainer}>
            {children}
        </div>
    );
};