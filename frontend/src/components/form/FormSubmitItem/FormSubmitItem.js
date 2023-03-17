import './FormSubmitItem.css';

export default function FormSubmitItem(props){
    return (
        <input id={props.Identifier} className="component-form-formsubmititem" type="submit" value={props.Value}></input>
    );
}