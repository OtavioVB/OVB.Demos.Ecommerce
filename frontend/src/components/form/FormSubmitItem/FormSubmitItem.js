import './FormSubmitItem.css';

export default function FormSubmitItem({Identifier, Value}){
    return (
        <input id={Identifier} className="component-form-formsubmititem" type="submit" value={Value}></input>
    );
}