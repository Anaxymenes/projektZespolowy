import React, {Component} from 'react';
import {Form, Input, TextArea, Button, Label, Image} from 'semantic-ui-react';


class AddGroupForm extends Component {
    state = { 
        groupName: '',
        groupDesc: '', 
        groupAvatar: [],
        imageUrl:''
    }

    handleChange = (e, { name, value }) => this.setState({ [name]: value })

    fileSelectedHandler = (e,value) => {
        // var file = e.target.files[0];
        // this.setState({groupAvatar: e.target.files[0]});
        // var reader = new FileReader();
        // var url = reader.readAsDataURL(file);
        const file    = e.target.files[0];
        const reader  = new FileReader();
    
        reader.onloadend = () => {
            this.setState({
                imageUrl: reader.result
            })
        }
        if (file) {
            reader.readAsDataURL(file);
            this.setState({
                imageUrl :reader.result,
                groupAvatar: file
            })
        } 
        else {
            this.setState({
                imageUrl: ""
            })
        }

    }

    render() {
        const {groupName, groupDesc, groupAvatar} =this.state
        return (
            <div>
                <h1>Dodaj grupę zaintereswań
                </h1>
                <Form>
                    <Form.Field>
                        <Label>Nazwa grupy</Label>
                        <Input 
                        placeholder='Nazwij swoją grupę...'
                        name='groupName'
                        value={groupName}
                        onChange={this.handleChange}
                        />
                    </Form.Field>
                    <Form.Field>
                        <label>Opis grupy</label>
                        <TextArea
                        placeholder='Nazwij swoją grupę...'
                        name='groupDesc'
                        value={groupDesc}
                        onChange={this.handleChange}
                        />
                    </Form.Field>
                    <Form.Field>
                        <label>Avatar grupy
                        </label>
                        <Input 
                        type='file'
                        accept="image/*"
                        name='groupAvatar'
                        //value={groupAvatar} 
                        onChange={this.fileSelectedHandler}
                        />
                    </Form.Field>
                    <Label> Podgląd obrazka</Label>
                     <Image src={this.state.imageUrl} size='small' />
                    <Button type='submit'>Submit</Button>

                </Form>
            </div>
        );
    }
}

export default AddGroupForm;