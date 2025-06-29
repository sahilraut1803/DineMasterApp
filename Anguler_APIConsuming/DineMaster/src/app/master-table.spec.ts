import { TestBed } from '@angular/core/testing';

import { MasterTable } from './master-table';

describe('MasterTable', () => {
  let service: MasterTable;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MasterTable);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
