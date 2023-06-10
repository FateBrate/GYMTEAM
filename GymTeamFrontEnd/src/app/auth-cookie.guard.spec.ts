import { TestBed } from '@angular/core/testing';

import { AuthCookieGuard } from './auth-cookie.guard';

describe('AuthCookieGuard', () => {
  let guard: AuthCookieGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(AuthCookieGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
