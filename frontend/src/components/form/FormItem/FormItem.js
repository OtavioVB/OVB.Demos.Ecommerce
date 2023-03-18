import './FormItem.css';

export default function FormItem({Identifier, Text, TypeInput, Placeholder}){
    return (
        <div className="form-item-component">
            <label htmlFor={Identifier} className="form-item-component-label">{Text}</label>
            <input id={Identifier} maxLength="256" className="form-item-component-input" type={TypeInput} placeholder={Placeholder}></input>
        </div>
    );
}