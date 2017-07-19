using System;
using System.Collections;
using System.Collections.Generic;

namespace GoTournamental.API.Interface {

	#region SQL Methods
	public interface ISQLInsertable {   
		void SQLInsert<T>(T objectToInsert);
	}
    public interface ISQLInsertableReturningID {
        int SQLInsertAndReturnID<T>(T objectToInsert);
    }
	public interface ISQLInsertableOrUpdateable {   
		void SQLInsertOrUpdate<T>(T objectToInsertOrUpdate);
	}	    
    public interface ISQLSelectable {   
		T SQLSelect<T, U>(U objectID);
	}		
	public interface ISQLAllSelectable {   
		List<T> SQLSelectAll<T>();
	}	
	public interface ISQLUpdateable {   
		void SQLUpdate<T>(T objectToUpdate);
	}	
	public interface ISQLDeletable {   
		void SQLDelete<T>(T objectToDelete);
	}
	public interface ISQLDeleteCascadable {
        void SQLDeleteWithCascade<T>(T objectToDelete);
	}
	public interface ISQLExistsQueryable {   
		bool SQLExists<T, U>(U objectID);
	}	
	#endregion



}