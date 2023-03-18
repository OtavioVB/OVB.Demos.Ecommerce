import './FormItem.css';

export default function FormItem({Identifier, Text, TypeInput, Placeholder, Value, OnChange}){
    return (
        <div className="form-item-component">
            <label htmlFor={Identifier} className="form-item-component-label">{Text}</label>
            <input value={Value} onChange={OnChange} id={Identifier} maxLength="256" className="form-item-component-input" type={TypeInput} placeholder={Placeholder}></input>
        </div>
    );
}