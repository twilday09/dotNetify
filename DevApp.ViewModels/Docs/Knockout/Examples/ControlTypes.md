﻿##### ControlTypes.html

```html
<table data-vm="ControlTypesVM">
  <tr>
    <td>
      Text box:
      <label>(updates on losing focus)</label>
    </td>
    <td>
      <input type="text" class="form-control" data-bind="value: TextBoxValue, attr: { placeholder: TextBoxPlaceHolder }" />
      <b data-bind="html: TextBoxResult"></b>
    </td>
  </tr>
  <tr>
    <td>
      Search box:
      <label>(updates on keystroke)</label>
    </td>
    <td>
      <input type="text" class="form-control" data-bind="textInput: SearchBox, attr: { placeholder: SearchBoxPlaceHolder }" />
      <ul class="list-group" data-bind="foreach: SearchResults">
        <li class="list-group-item" data-bind="text: $data"></li>
      </ul>
    </td>
  </tr>
  <tr>
    <td>Check box:</td>
    <td>
      <label>
        <input type="checkbox" data-bind="checked: ShowMeCheckBox" />
        <span>Show me</span>
      </label>
      <label>
        <input type="checkbox" data-bind="checked: EnableMeCheckBox" />
        <span>Enable me</span>
      </label>
      <button class="btn btn-secondary" data-bind="html: CheckBoxResult, enable: EnableMeCheckBox, visible: ShowMeCheckBox" />
    </td>
  </tr>
  <tr>
    <td>Simple drop-down list:</td>
    <td>
      <select class="form-control" data-bind="options: SimpleDropDownOptions, value: SimpleDropDownValue, optionsCaption: 'Choose...'"></select>
      <b data-bind="html: SimpleDropDownResult"></b>
    </td>
  </tr>
  <tr>
    <td>Drop-down list:</td>
    <td>
      <select class="form-control" data-bind="options: DropDownOptions, optionsText: 'Text', optionsValue: 'Id',
        optionsCaption: DropDownCaption, value: DropDownValue"></select>
      <b data-bind="html: DropDownResult"></b>
    </td>
  </tr>
  <tr>
    <td>Radio button:</td>
    <td>
      <label>
        <input type="radio" value="green" data-bind="checked: RadioButtonValue" />
        <span>Green</span>
      </label>
      <label>
        <input type="radio" value="yellow" data-bind="checked: RadioButtonValue" />
        <span>Yellow</span>
      </label>
      <button class="btn" data-bind="css: RadioButtonStyle">Result</button>
    </td>
  </tr>
  <tr>
    <td>Button:</td>
    <td>
      <button class="btn btn-secondary" type="button" data-bind="vmCommand: ButtonClicked">Click me</button>
      <span style="margin-left: 2rem" data-bind="if: ClickCount() > 0">You clicked me
        <b data-bind="text: ClickCount"></b> times!</span>
    </td>
  </tr>
</table>
```