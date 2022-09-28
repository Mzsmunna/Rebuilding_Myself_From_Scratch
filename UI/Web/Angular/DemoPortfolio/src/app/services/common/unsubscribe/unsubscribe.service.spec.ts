import { TestBed } from '@angular/core/testing';

import { UnsubscribeService } from './unsubscribe.service';

describe('UnsubscribeService', () => {
  let service: UnsubscribeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UnsubscribeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
