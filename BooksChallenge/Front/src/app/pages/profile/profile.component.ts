import { Component } from '@angular/core';

@Component({
  templateUrl: 'profile.component.html',
  styleUrls: [ './profile.component.scss' ]
})

export class ProfileComponent {
  employee: any;
  colCountByScreen: object;

  constructor() {
    this.employee = {
      ID: 1,
      FirstName: 'Thibaud',
      LastName: 'ROBERT',
      Prefix: 'M.',
      Position: 'Developper',
      Picture: 'https://media-exp1.licdn.com/dms/image/C5603AQHxbxCzTn9QNw/profile-displayphoto-shrink_800_800/0/1517411883312?e=1643846400&v=beta&t=pXVIDU0hzhufpdibZ2JNdBIoLutpLx-xWv-y5CgK6Vw',
      BirthDate: new Date('1989/06/26'),
      HireDate: null,
      /* tslint:disable-next-line:max-line-length */
      Notes: '',
      Address: ''
    };
    this.colCountByScreen = {
      xs: 1,
      sm: 2,
      md: 3,
      lg: 4
    };
  }
}
