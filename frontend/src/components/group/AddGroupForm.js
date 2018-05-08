import React, {Component} from 'react';
import {Form, Input, TextArea} from 'semantic-ui-react';
class AddGroupForm extends Component {
    render() {
        return (
            <div>
                <h1>Dodaj grupę zaintereswań
                </h1>
                <Form>
                    <Form.Field>
                        <label>Nazwa grupy</label>
                        <input placeholder='Nazwij swoją grupę...'/>
                    </Form.Field>
                    {/* <Form.Field control={TextArea} label='O grupie' placeholder='Napisz coś o swojej grupie...' /> */}
                    {/* <From.Field> */}
                        {/* <label>Nazwa grupy </label> */}
                        {/* <textarea placeholder='Napisz coś...' /> */}
                    {/* </From.Field> */}
                </Form>
            </div>
        );
    }
}

export default AddGroupForm;