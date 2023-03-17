import './FormSubmitItem.css';

export default function FormSubmitItem(props){
    return (
        <input id={props.Identifier} class="component-form-formsubmititem" type="submit" value={props.Value}></input>
    );
}