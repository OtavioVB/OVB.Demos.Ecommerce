import styles from './NotificationContainer.module.css';
import { v4 as uuidv4 } from 'uuid';

export function NotificationContainer({children}){
    return (
        <div className={styles.NotificationContainer}>
            {children}
        </div>
    );
};

export function GenerateNotification(text){
    return { Text: text, Id: uuidv4(), Type: "Error" };
}

export function GenerateSuccessNotification(text){
    return { Text: text, Id: uuidv4(), Type: "Success" };
}