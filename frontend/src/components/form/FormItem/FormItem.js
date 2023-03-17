import './FormItem.css';

export default function FormItem(props){
    return (
        <div className="form-item-component">
            <label htmlFor={props.Identifier} className="form-item-component-label">{props.Text}</label>
            <input id={props.Identifier} className="form-item-component-input" type={props.TypeInput} placeholder={props.Placeholder}></input>
        </div>
    );
}