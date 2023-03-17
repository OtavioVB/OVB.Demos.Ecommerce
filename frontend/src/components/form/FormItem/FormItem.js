import './FormItem.css';

export default function FormItem(props){
    return (
        <div class="form-item-component">
            <label for={props.Identifier} class="form-item-component-label">{props.Text}</label>
            <input id={props.Identifier} class="form-item-component-input" type={props.TypeInput} placeholder={props.Placeholder}></input>
        </div>
    );
}