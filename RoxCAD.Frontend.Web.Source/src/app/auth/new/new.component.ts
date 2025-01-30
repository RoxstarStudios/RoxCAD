
import { Component, OnInit, signal } from '@angular/core';
import { NavbarComponent } from '../../shared/navbar/navbar.component';

@Component({
  selector: 'app-new',
  standalone: true,
  imports: [NavbarComponent],
  templateUrl: './new.component.html',
  styleUrl: './new.component.css'
})
export class NewComponent implements OnInit {
  constructor() {}

  isUsernameValid = signal(false);
  username = signal("" as any);
  isEmailValid = signal(false);
  emailAddress = signal("" as any);
  unhashedPassword = signal("" as any);
  unhashedVerifyPassword = signal("" as any);
  isPasswordMatch = signal(false);
  isPasswordLengthGood = signal(false);

  ngOnInit(): void {
    
  }

  onUsernameInputChange = (event: Event) => {
    const inputValue = (event.target as HTMLInputElement).value;

    if (inputValue.length >= 5) {
      this.isUsernameValid.set(true);
    } else {
      this.isUsernameValid.set(false);
    }

    this.username.set(inputValue.toLowerCase());
  }

  onEmailInputChange = (event: Event) => {
    const inputValue = (event.target as HTMLInputElement).value;

    if (this.isValidEmail(inputValue)) {
      this.isEmailValid.set(true);
      this.emailAddress.set(inputValue);
    } else {
      this.isEmailValid.set(false);
      this.emailAddress.set("");
    }
  }

  onPasswordInputChange = (event: Event) => {
    const inputValue = (event.target as HTMLInputElement).value;

    if (inputValue.length >= 5) {
      this.isPasswordLengthGood.set(true);
    } else {
      this.isPasswordLengthGood.set(false);
    }

    this.unhashedPassword.set(inputValue);
  }

  onVerifyPasswordInputChange = (event: Event) => {
    const inputValue = (event.target as HTMLInputElement).value;

    if (this.unhashedPassword() === inputValue) {
      this.isPasswordMatch.set(true);
      this.unhashedVerifyPassword.set(inputValue);
    } else {
      this.isPasswordMatch.set(false);
      this.unhashedVerifyPassword.set("");
    }
  }

  isValidEmail = (email: string): boolean => {
    const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return emailPattern.test(email);
  }
}
