import "./SeparatorHorizontal.css";

export default function SeparatorHorizontal(props){
    if(props.Text != null){
        return (
            <div class="component-content-separator-separator-horizontal-with-text">
                <span class="component-separator-horizontal-with-text"></span>
                <p class="component-text-for-separator-horizontal">{props.Text}</p>
                <span class="component-separator-horizontal-with-text"></span>
            </div>
        );
    }

    return (
        <span class="component-separator-horizontal"></span>
    );
}