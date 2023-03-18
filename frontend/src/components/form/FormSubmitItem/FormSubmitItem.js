import './FormSubmitItem.css';

export default function FormSubmitItem({Identifier, Value, OnClick}){
    return (
        <input id={Identifier} onClick={OnClick} className="component-form-formsubmititem" type="submit" value={Value}></input>
    );
}